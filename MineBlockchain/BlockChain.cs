using System;
using System.Collections.Generic;
using System.Linq;

namespace Bloco_Blockchain
{
    public class BlockChain
    {
        private readonly int _proofOfWorkDifficulty;
        private readonly double _miningReward;

        private List<Transaction> _pedindTrasactions;
        public List<Block> Chain { get; set; }

        public BlockChain(int proofOfWorkDifficulty, int mininReward)
        {
            _proofOfWorkDifficulty = proofOfWorkDifficulty;
            _miningReward = mininReward;
            _pedindTrasactions = new List<Transaction>();
            Chain = new List<Block>() { CreateGenesisBlock() };
        }

        public void CreateTransaction(Transaction transaction)
        {
            _pedindTrasactions.Add(transaction);
        }

        public void MineBlock(string minerAddress)
        {
            Transaction minerRewardTransaction = new Transaction(null, minerAddress, _miningReward);
            _pedindTrasactions.Add(minerRewardTransaction);

            Block block = new Block(DateTime.Now, _pedindTrasactions);
            block.MineBlock(_proofOfWorkDifficulty);

            block.PreviousHash = Chain.Last().Hash;
            Chain.Add(block);

            _pedindTrasactions = new List<Transaction>();
        }

        public bool IsValidChain()
        {
            for(int i = 1; i < Chain.Count; i++)
            {
                Block previousBlock = Chain[i - 1];
                Block currentBlock = Chain[i];

                if(currentBlock.Hash != currentBlock.CreateHash())
                    return false;
                if(currentBlock.PreviousHash != previousBlock.Hash)
                    return false;
            }
            return true;
        }

        public double GetBalance(string address)
        {
            double balance = 0;

            foreach(Block block in Chain)
            {
                foreach(Transaction transaction in block.Transactions)
                {
                    if (transaction.From == address)
                        balance -= transaction.Amount;

                    if(transaction.To == address)
                        balance += transaction.Amount;
                }
            }
            return balance;
        }

        private Block CreateGenesisBlock()
        {
            List<Transaction> transactions = new List<Transaction> { new Transaction("", "", 0) };
            return new Block(DateTime.Now, transactions, "0");
        }
    }
}
