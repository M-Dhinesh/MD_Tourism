using Administrator.Interfaces;
using Administrator.Models;
using Microsoft.EntityFrameworkCore;
using TravelAgents.Models;

namespace Administrator.Services
{
    public class TravelAgentRepo: IRepo<TravelAgent, string>
        {
            private readonly Context _context;
            public TravelAgentRepo(Context context)
            {
                _context = context;
            }

            public async Task<TravelAgent?> Add(TravelAgent item)
            {
                var agent_mail = _context.TravelAgents.SingleOrDefault(d => d.Email == item.Email);
                if (agent_mail == null)
                {
                    try
                    {
                        _context.TravelAgents.Add(item);
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

            public async Task<TravelAgent?> Delete(string id)
            {
                try
                {
                    TravelAgent? agent = await Get(id);
                    if (agent != null)
                    {
                        _context.TravelAgents.Remove(agent);
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

            public async Task<TravelAgent?> Get(string id)
            {
                try
                {
                    var agent = await _context.TravelAgents.SingleOrDefaultAsync(a => a.Email == id);
                    if (agent == null)
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

            public async Task<ICollection<TravelAgent>?> GetAll()
            {
                try
                {
                    var agents = await _context.TravelAgents.ToListAsync();
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

            public async Task<TravelAgent?> Update(TravelAgent item)
            {
                var agent = _context.TravelAgents.SingleOrDefault(a => a.Email == item.Email);
                if (agent != null)
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