using BusinessObject;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IEmailTokenRepository
    {
        Task<EmailToken> GetTokenByAccountId(Guid accountId); 
        Task<EmailToken> CreateToken(EmailToken token);
    }

    public class EmailTokenRepository : IEmailTokenRepository
    {
        public async Task<EmailToken> CreateToken(EmailToken token) =>await EmailTokenDAO.Instance.CreateEmailToken(token);
         
        public async Task<EmailToken> GetTokenByAccountId(Guid accountId) =>await EmailTokenDAO.Instance.GetEmailTokenByAccountID(accountId);
         
    }
}
