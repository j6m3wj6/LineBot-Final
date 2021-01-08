﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LineBot.Models;
using LineBot.Repositories;
using MongoDB.Bson;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LineBot.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static readonly UsersServicies _usersServicies = new UsersServicies();

        //public UsersController(UsersServicies usersServicies)
        //{
        //    _usersServicies = usersServicies;
        //}

        [HttpGet] //List<BsonDocument> //_usersServicies.Get()
        public ActionResult<String> Get() =>
             _usersServicies.Get();



        //[HttpGet("{id:length(24)}", Name = "GetBook")]
        //public ActionResult<User> Get(string id)
        //{
        //    var user = _usersServicies.Get(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        //[HttpPost]
        //public ActionResult<User> Create(User user)
        //{
        //    _usersServicies.Create(user);

        //    return CreatedAtRoute("GetBook", new { id = user.Id.ToString() }, user);
        //}

        //[HttpPut("{id:length(24)}")]
        //public IActionResult Update(string id, User userIn)
        //{
        //    var user = _usersServicies.Get(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _usersServicies.Update(id, userIn);

        //    return NoContent();
        //}

        //[HttpDelete("{id:length(24)}")]
        //public IActionResult Delete(string id)
        //{
        //    var user = _usersServicies.Get(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _usersServicies.Remove(user.Id);

        //    return NoContent();
        //}

    }
}