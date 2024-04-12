using Microsoft.AspNetCore.Mvc;
using tradeBot.DAL.Entities
using Refit;    

namespace tradeBot.Connector.API;

public interface IUserApi
{
    [Headers("Accept: text/plain, application/json, text/json")]
    [HttpPost("/GetUserById")]
    Task<ICollection<UserViewModel>> GetUserById();
}