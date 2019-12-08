using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ganache.API.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Sender_username { get; set; }
        public string Recepient_username { get; set; }

        public string Sender_publicKey { get; set; }
        public string Recepient_publicKey { get; set; }

        public long Credit_Amount { get; set; }
        public long Ether_Amount { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime TransactionDateTime { get; set; }

    }
}
