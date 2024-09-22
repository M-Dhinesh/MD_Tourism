using AccountAPI.Interfaces;
using AccountAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AccountAPI.Services
{
    public class AgentRepo:IRepo<Agent,string>
    {
        private readonly Context _context;
        public AgentRepo(Context context)
        {
            _context = context;
        }

        public async Task<Agent?> Add(Agent item)
        {
            var agent_mail = _context.Agents.SingleOrDefault(d => d.Email == item.Email);
            if (agent_mail == null)
            {
                try
                {
                    _context.Agents.Add(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        public async Task<Agent?> Delete(string id)
        {
            try
            {
                var agent = await Get(id);
                if (agent != null)
                {
                    _context.Agents.Remove(agent);
                    await _context.SaveChangesAsync();

                    return agent;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agent?> Get(string id)
        {
            try
            {
                var agent = await _context.Agents.SingleOrDefaultAsync(a => a.Email == id);
                if(agent == null)
                {
                    return null;
                }
                return agent;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<ICollection<Agent>?> GetAll()
        {
            try
            {
                var agents = await _context.Agents.ToListAsync();
                if (agents != null)
                {
                    return agents;
                }
                return null;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<Agent?> Update(Agent item)
        {
            var agent = _context.Agents.SingleOrDefault(a => a.Email == item.Email);
            if( agent != null)
            {
                try
                {
                    agent.Name = item.Name;
                    agent.DateOfBirth = item.DateOfBirth;
                    agent.Address = item.Address;
                    agent.Phone = item.Phone;
                    agent.Gender = item.Gender;
                    agent.AgencyID = item.AgencyID;
                    agent.AgencyName = item.AgencyName;
                    agent.GSTnumber = item.GSTnumber;
                    await _context.SaveChangesAsync();
                    return agent;
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
            return null;
        }
    }
}
