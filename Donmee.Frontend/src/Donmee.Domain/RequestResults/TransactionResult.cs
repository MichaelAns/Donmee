﻿namespace Donmee.Domain.RequestResults
{
    public class TransactionResult
    {
        public bool Result { get; set; }

        public List<string> Errors { get; set; }
    }
}
