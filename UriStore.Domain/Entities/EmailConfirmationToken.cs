﻿using UriStore.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UriStore.Domain.Entities
{
    public class EmailConfirmationToken : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        [StringLength(250)]
        public string Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }

}
