using Azure.Core;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class EmailTokenDAO
    {
        private static readonly object InstanceLock = new object();
        private static EmailTokenDAO instance = null;

        public static EmailTokenDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmailTokenDAO();
                    }
                    return instance;
                }
            }
        }

        public async Task<EmailToken> GetEmailTokenByAccountID(Guid accountID)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    return await context.EmailTokens.SingleOrDefaultAsync(item => item.AccountID == accountID);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmailToken> CreateEmailToken(EmailToken newItem)
        {
            try
            {
                using (var context = new VemsContext())
                {
                    var checkExist = await context.EmailTokens
                           .FirstOrDefaultAsync(s => s.AccountID == newItem.AccountID);

                    if (checkExist != null)
                    {
                         context.EmailTokens.Remove(checkExist);
                        await context.SaveChangesAsync();
                    }

                    var e = context.EmailTokens.Add(newItem).Entity;
                    context.SaveChanges();
                    return e;
               
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
