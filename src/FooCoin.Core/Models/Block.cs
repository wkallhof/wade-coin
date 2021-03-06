using System;

namespace FooCoin.Core.Models
{
    public class Block : IHashable
    {
        public string PreviousBlockHash { get; set; }
        public long UnixTimeStamp { get; set; }
        public int Difficulty { get; set; }
        public string Nonce { get; set; }
        public Transaction Transaction { get; set; }

        public string Hash { get; set; }
        public string Miner { get; set; }
        
        public Block(string previousBlockHash, Transaction transaction){
            Transaction = transaction;
            PreviousBlockHash = previousBlockHash ?? string.Empty;
        }

        public string GetHashMessage(ICrypto crypto)
        {
            return $"{PreviousBlockHash}{UnixTimeStamp}{Difficulty}{Nonce}{crypto.Hash(Transaction)}";
        }
    }
}