using Microsoft.EntityFrameworkCore;
using SistemaCrossfit.Data;
using SistemaCrossfit.DTO;
using SistemaCrossfit.Extensions;
using SistemaCrossfit.Models;
using SistemaCrossfit.Repositories.Interface;
using SistemaCrossfit.Request;

namespace SistemaCrossfit.Repositories
{
    public class ContentManagementRepository : IContentManagementRepository
    {
        private readonly AppDBContext _dbContext;
        public ContentManagementRepository(AppDBContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task CreateorUpdate(ContentManagementRequest entityModel)
        {
            var T = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var content = await _dbContext.ContentManagement.FirstOrDefaultAsync();
                if(content == null)
                {
                    var contentManagement = new ContentManagement()
                    {
                        AboutDescription = entityModel.AboutDescription,
                        EmailContact = entityModel.EmailContact,
                        IdAddress = entityModel.IdAddress,
                        IdAdmin = entityModel.IdAdmin,
                        IsMain = entityModel.IsMain,
                        LogoImgUrl = entityModel.LogoImgUrl.ToBase64String(),
                        MainImgUrl = entityModel.MainImgUrl.ToBase64String(),
                        PageTitle = entityModel.PageTitle,
                        SubTitulo = entityModel.SubTitulo,
                        Telephone = entityModel.Telephone,
                        Titulo = entityModel.Titulo,
                        Whatsapp = entityModel.Whatsapp,
                        CreatedAt = DateTime.Now,
                    };
                    await _dbContext.ContentManagement.AddAsync(contentManagement);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    content.AboutDescription = entityModel.AboutDescription;
                    content.EmailContact = entityModel.EmailContact;
                    content.IdAddress = entityModel.IdAddress;
                    content.IdAdmin = entityModel.IdAdmin;
                    content.IsMain = entityModel.IsMain;
                    content.LogoImgUrl = entityModel.LogoImgUrl.ToBase64String();
                    content.MainImgUrl = entityModel.MainImgUrl.ToBase64String();
                    content.PageTitle = entityModel.PageTitle;
                    content.SubTitulo = entityModel.SubTitulo;
                    content.Telephone = entityModel.Telephone;
                    content.Titulo = entityModel.Titulo;
                    content.Whatsapp = entityModel.Whatsapp;
                    content.UpdatedAt = DateTime.Now;
                    _dbContext.ContentManagement.Update(content);
                    await _dbContext.SaveChangesAsync();
                }
                await T.CommitAsync();
            }
            catch (Exception ex)
            {
                await T.RollbackAsync();
                throw ex;
            }   
        }

        public async Task<ContentManagementDto> Get()
        {
            try
            {
                var content = await _dbContext.ContentManagement.Include(x => x.Address).FirstOrDefaultAsync();
                if(content == null)
                {
                    throw new Exception("Content not found!");
                }
                var contentManagement = new ContentManagementDto()
                {
                    AboutDescription = content.AboutDescription,
                    EmailContact = content.EmailContact,
                    Address = new Address()
                        {
                            IdAddress = content.Address.IdAddress,
                            PostalCode = content.Address.PostalCode,
                            Country = content.Address.Country,
                            City = content.Address.City,
                            Street = content.Address.Street,
                            Number = content.Address.Number,
                            Neighborhood = content.Address.Neighborhood,
                            Complement = content.Address.Complement
                        },
                    IsMain = content.IsMain,
                    LogoImgUrl = content.LogoImgUrl,
                    MainImgUrl = content.MainImgUrl,
                    PageTitle = content.PageTitle,
                    SubTitulo = content.SubTitulo,
                    Telephone = content.Telephone,
                    Titulo = content.Titulo,
                    Whatsapp = content.Whatsapp,
                };
                return contentManagement;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
