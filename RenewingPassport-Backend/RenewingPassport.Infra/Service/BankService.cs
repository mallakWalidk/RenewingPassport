using RenewingPassport.Core.Data;
using RenewingPassport.Core.DTO;
using RenewingPassport.Core.Repository;
using RenewingPassport.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace RenewingPassport.Infra.Service
{
    public class BankService: IBankService
    {
        private readonly IBankRepository bankRepository;

        public BankService(IBankRepository _bankRepository)
        {
            bankRepository = _bankRepository;
            
        }

        public StringDTO CheckVisa(Bank bank)
        {
            Bank bankAccount = bankRepository.GetBankByID(1);
            StringDTO text=new StringDTO();
            if (bank.Name_On_Visa==bankAccount.Name_On_Visa && bank.Visa_Number == bankAccount.Visa_Number && bank.Visa_Cvv == bankAccount.Visa_Cvv &&bank.Year1== bankAccount.Year1&&bank.Month1== bankAccount.Month1)
            {
                if (50> bankAccount.Balance)
                {
                    text.Message = "Low Balance";
                    return text;
                }
                else
                {
                    text.Message = "payment succeed";

                    return text;
                }
            }
            else
            {
                text.Message = "Wrong visa information";
                return text;
            }


            
        }
    }
}
