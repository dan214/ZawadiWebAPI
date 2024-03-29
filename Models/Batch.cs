﻿using System.Runtime.Serialization;

namespace ZetechWebAPI.Models
{
    public class Batch
    {
        public int BatchId { get; set; }

        public string? BatchName { get; set; }

        public string? Description { get; set; }

        public DateTime? DateCreated { get; set; }
        
    }
}
