using System;
using System.IO;
using MediatR;
using Microsoft.AspNetCore.Http;
using SBA.Expense.Commands;
using SBA.Expense.Common;
using SBA.Expense.Models;

namespace SBA.Expense.Controllers.Parameters
{
    public class UploadRequest
    {
        public UploadRequest()
        {

        }

        public string UserID { get; set; }
        public Guid InvoiceId { get; set; }
        public IFormFile File { get; set; }

        public AttachReceipt ToAttachReceipt()
        {
            MemoryStream s = new MemoryStream();
            File.CopyTo(s);
            s.Position = 0;
            AttachReceipt returnValue = new AttachReceipt(Guid.NewGuid(), InvoiceId, UserID, s.ToArray());
            returnValue.FileName= File.FileName;
            return returnValue;
        }

    }
}