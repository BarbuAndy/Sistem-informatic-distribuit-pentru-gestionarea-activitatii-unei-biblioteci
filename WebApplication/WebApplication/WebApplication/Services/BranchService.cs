using Olympia_Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using WebApplication.Models;
using WebApplication.Repositories;

namespace WebApplication.Services
{
    public class BranchService : BaseService
    {
        public BranchService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }

        public void AddBranch(BranchModel branch)
        {
            Branch new_branch = new Branch();
            new_branch.Name = branch.Name;
            new_branch.LibraryId = 1; //----------------- TO DO
            new_branch.Location = branch.Location;

            repositoryWrapper.BranchRepository.Create(new_branch);
        }

        public void UpdateBranch(BranchModel branch)
        {

            Branch updated_branch = new Branch();
            updated_branch = GetBranchByCondition(b => b.Name == branch.Name).First();
            if (branch.Location != null)
            {
                updated_branch.Location = branch.Location;
            }

            repositoryWrapper.BranchRepository.Update(updated_branch);
        }

        public void DeleteBranch(BranchModel branch)
        {
            repositoryWrapper.BranchRepository.Delete(GetBranchByCondition(b => b.Name == branch.Name).First());
        }

        public List<Branch> GetBranchByCondition(Expression<Func<Branch, bool>> expression)
        {
            return repositoryWrapper.BranchRepository.FindByCondition(expression).ToList();
        }

        public List<string> ExtractBranchNames()
        {
            List<Branch> branches = GetBranchByCondition(b => b.BranchId != -1);
            List<string> BranchNames = new List<string>();
            foreach (var author in branches)
            {
                BranchNames.Add(author.Name);
            }
            return BranchNames;
        }
    }

}