using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Praxisarbeit.Model;
using System;
using System.Linq;
using Praxisarbeit.Dto;

[ApiController]
[Route("api/[controller]")]
public class RegistrationController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public RegistrationController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult GetAllRegistrations()
    {
        var registrations = _dbContext.Registrations.ToList();
        return Ok(registrations);
    }

    [HttpGet("{name}")]
    public IActionResult GetRegistrationByName(string name)
    {
        var registration = _dbContext.Registrations.FirstOrDefault(r => r.Name == name);

        if (registration == null)
        {
            return NotFound("Registration not found");
        }

        return Ok(registration);
    }

    [HttpPost]
    public IActionResult CreateRegistration([FromBody] RegistrationDto registrationDto)
    {
        if (registrationDto == null)
        {
            return BadRequest("Invalid data");
        }

        try
        {
            var registrationModel = new Order
            {
                Name = registrationDto.Name,
                Email = registrationDto.Email,
                Phone = registrationDto.Phone,
                PriorityId = registrationDto.PriorityId,
                ServiceId = registrationDto.ServiceId,
                CreateDate = DateTime.Now,
                PickupDate = registrationDto.PickupDate
            };
            if (registrationDto.UserId != null)
            {
                registrationModel.UserId = registrationDto.UserId;
                
            }

            _dbContext.Registrations.Add(registrationModel);
            _dbContext.SaveChanges();

            return Ok("Data received successfully and saved to the database");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }

    [HttpPut("{name}")]
    public IActionResult UpdateRegistration(string name, [FromBody] RegistrationDto registrationDto)
    {
        var existingRegistration = _dbContext.Registrations.FirstOrDefault(r => r.Name == name);

        if (existingRegistration == null)
        {
            return NotFound("Registration not found");
        }

        existingRegistration.Name = registrationDto.Name;
        existingRegistration.Email = registrationDto.Email;
        existingRegistration.Phone = registrationDto.Phone;
        existingRegistration.PriorityId = registrationDto.PriorityId;
        existingRegistration.ServiceId = registrationDto.ServiceId;
        existingRegistration.PickupDate = registrationDto.PickupDate;

        _dbContext.SaveChanges();

        return Ok("Registration updated successfully");
    }
  


    [HttpDelete("{name}")]
    [Authorize]
    public IActionResult DeleteRegistration(string name)
    {
        var registration = _dbContext.Registrations.FirstOrDefault(r => r.Name == name);

        if (registration == null)
        {
            return NotFound("Registration not found");
        }

        _dbContext.Registrations.Remove(registration);
        _dbContext.SaveChanges();

        return Ok("Registration deleted successfully");
    }
}
