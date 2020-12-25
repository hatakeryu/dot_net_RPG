using System.Collections.Generic; 
using dot_net_RPG.Models;

namespace Models
{
  public class User
  { 
    public int Id { get; set; }
    public string Username { get; set; }

    public byte[] PasswordHash { get; set; }
    public byte[] PassWordSalt { get; set; }

    public List<Character> Character { get; set; }
  }
}