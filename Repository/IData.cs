using Bar_rating.Models;
using System.Collections.Generic;

namespace Bar_rating.Repository
{
    public interface IData
    {
        bool DeleteMember(string id);
        List<Member> GetAllMembers();
    }
}
