﻿using Helper.Models;
using InfoService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace InfoService.Controllers
{
    [Route("api/Info/[controller]/[action]")]
    [ApiController]
    public class DriverController : BaseController
    {
        [HttpGet]
        public async Task<ResponseMsg> GetDrivers()
        {
            return new ResponseMsg {
                status = true,
                data = await Repository.Driver.GetAllDrivers(),
                message = "Get all driver info success"
            };
        }

        [HttpPost]
        public async Task<ResponseMsg> AddInfo(Driver driver)
        {
            int result = await Repository.Driver.AddDriverInfo(driver);
            if(result > 0)
            {
                return new ResponseMsg
                {
                    status = true,
                    data = new {accountId = driver.AccountId},
                    message = "Add driver info success"
                };
            }
            else
            {
                return new ResponseMsg
                {
                    status = false,
                    data = null,
                    message = "Add driver info failed"
                };
            }
        }

        [HttpPost]
        public async Task<ResponseMsg> GetDriverInfoById(object accountObj)
        {
            JObject objTemp = JObject.Parse(accountObj.ToString());
            string id = (string)objTemp["accountId"];
            Driver driver = await Repository.Driver.GetDriverById(Guid.Parse(id));
            if (driver is null)
            {
                return new ResponseMsg
                {
                    status = false,
                    data = null,
                    message = "Get driver info failed, driver does not exist"
                };
            }
            else
            {
                return new ResponseMsg
                {
                    status = false,
                    data = driver,
                    message = "Get driver info success"
                };
            }
        }

        [HttpPost]
        public async Task<ResponseMsg> UpdateInfo(Driver driver)
        {
            if(await Repository.Driver.CheckDriverExist(driver.AccountId))
            {
                int res = await Repository.Driver.UpdateDriverInfo(driver);
                if(res > 0)
                {
                    return new ResponseMsg
                    {
                        status = true,
                        data = null,
                        message = "Update driver info success"
                    };
                }
                // -4 email already exist
                // -3 phone already exist
                return new ResponseMsg
                {
                    status = false,
                    data = null,
                    message = res == -3 ? "Update failed, phone already existed": res == -4 ? "Update failed, email already existed" : "Update failed, nothing changed"
                };
            }
            else
            {
                return new ResponseMsg
                {
                    status = false,
                    data = null,
                    message = "Update driver info failed, driver does not exist"
                };
            }
        }

    }
}
