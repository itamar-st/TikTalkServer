﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public class TransferService : ITransferService
    {
        MessageService messageService = new MessageService();
        ContactService contactService = new ContactService();
       public bool SendMessage(Transfer transfer)
        {
            try
            {
                Contact currentContact = new Contact();
                JsonObject contentJson = new JsonObject();
                contentJson.Add("content", transfer.Content);
                // false because we got the message
                if(messageService.Create(transfer.To, transfer.From, contentJson, false) == false)
                {
                    return false;
                };
                contactService.EditLastMsg(transfer.To, transfer.From, contentJson["content"].ToString(), DateTime.Now.ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
