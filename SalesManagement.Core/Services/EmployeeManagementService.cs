﻿using Microsoft.EntityFrameworkCore;
using SalesManagement.Core.Convertors;
using SalesManagement.Core.DTOs;
using SalesManagement.Core.Services.Contracts;
using SalesManagement.Data.Context;
using SalesManagement.Data.Entities;

namespace SalesManagement.Core.Services
{
    public class EmployeeManagementService : IEmployeeManagementService
    {
        private readonly SalesManagementDbContext _context;

        public EmployeeManagementService(SalesManagementDbContext context)
        {
            _context = context;
        }



        public async Task<List<EmployeeViewModel>> GetEmployees()
        {
            try
            {
                return await _context.Employees.Convert();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<EmployeeJobTitle>> GetEmployeeJobTitles()
        {
            try
            {
                return await _context.EmployeeJobTitles.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}