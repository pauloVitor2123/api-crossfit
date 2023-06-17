using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Models;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Services
{
    public class PaymentService
    {
        private readonly AppDBContext _dbContext;
        public PaymentService(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<PaymentDto> GetOpenInvoice(int IdPayment)
        {
            var payment = await _dbContext.Payment
                .Include(x => x.PaymentType)
                .Include(x => x.Student)
                .Include(x => x.Status)
                .FirstOrDefaultAsync(x => x.IdPayment == IdPayment);
            
            if (payment == null) 
            {
                throw new Exception("Não foi encontrada a fatura");
            }

            var paymentDto = new PaymentDto()
            {
                IdPayment = payment.IdPayment,
                DatePayment = payment.DatePayment,
                DueDate = payment.DueDate,
                Invoice = payment.Invoice,
                PaymentType = payment.PaymentType ?? null,
                Status = payment.Status,
                Student = payment.Student
            };
            return paymentDto;
        }
        public async Task<List<PaymentDto>> GetPaymentByStudentId(int IdStudent)
        {
            var payment = await _dbContext.Payment
                .Include(x => x.PaymentType)
                .Include(x => x.Student)
                .Include(x => x.Status)
                .Where(x => x.Student.IdStudent == IdStudent)
                .ToListAsync();
            
            if (payment == null)
            {
                throw new Exception("Não foi encontradas faturas desse estudante");
            }
            var paymentsDto = new List<PaymentDto>();
            foreach (var item in payment)
            {
                paymentsDto.Add(new PaymentDto()
                {
                    IdPayment = item.IdPayment,
                    DatePayment = item.DatePayment,
                    DueDate = item.DueDate,
                    Invoice = item.Invoice,
                    PaymentType = item.PaymentType ?? null,
                    Status = item.Status,
                    Student = item.Student
                });
            }
            return paymentsDto;
        }
        public async Task CreatePayment(CreatePaymentRequest createPaymentRequest)
        {
            var T = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var student = await _dbContext.Student.FirstOrDefaultAsync(x => x.IdStudent == createPaymentRequest.IdStudent);
                
                if (student == null)
                {
                    throw new Exception("Não foi encontrado o estudante");
                }

                var paymentDb = await _dbContext.Payment
                    .Where(x => x.IdStudent == createPaymentRequest.IdStudent)
                    .OrderByDescending(x => x.IdPayment)
                    .LastOrDefaultAsync();
                
                var payment = new Payment()
                {
                    IdAdmin = createPaymentRequest.IdAdmin == 0 ? null :
                              createPaymentRequest.IdAdmin,
                    IdStudent = createPaymentRequest.IdStudent,
                    DueDate = paymentDb == null ? DateTime.Now.AddMonths(1) : paymentDb.DueDate.AddMonths(1),
                    IdStatus = 4,
                    CreatedAt = DateTime.Now,
                };

                await _dbContext.Payment.AddAsync(payment);
                await _dbContext.SaveChangesAsync();

                await T.CommitAsync();
            }
            catch (Exception ex)
            {
                await T.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
        public async Task UpdatePayment(UpdatePaymentRequest updatePaymentRequest)
        {
            var T = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var payment = await _dbContext.Payment.FirstOrDefaultAsync(x => x.IdPayment == updatePaymentRequest.IdPayment);
                if (payment == null)
                {
                    throw new Exception("Não foi encontrado a fatura");
                }
                payment.IdAdmin = updatePaymentRequest.IdAdmin;
                payment.IdPaymentType = updatePaymentRequest.IdPaymentType;
                payment.Invoice = updatePaymentRequest.Invoice;
                payment.DatePayment = updatePaymentRequest.DatePayment;
                payment.IdStatus = 3;
                await _dbContext.SaveChangesAsync();

                await T.CommitAsync();

                await CreatePayment(new CreatePaymentRequest()
                {
                    IdAdmin = updatePaymentRequest.IdAdmin,
                    IdStudent = payment.IdStudent
                });

            }
            catch (Exception ex)
            {
                await T.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }
    }
}
