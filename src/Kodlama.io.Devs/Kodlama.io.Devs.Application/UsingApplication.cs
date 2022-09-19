global using AutoMapper;
global using Core.Application.Pipelines.Validation;
global using Core.Application.Requests;
global using Core.Persistence.Paging;
global using Core.Persistence.Repositories;
global using FluentValidation;
global using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
global using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
global using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;


// Github
global using Kodlama.io.Devs.Domain.Entities;
global using Core.CrossCuttingConcerns.Exceptions;
global using Kodlama.io.Devs.Application.Services.Repositories;
global using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Dtos;
global using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Rules;
global using Kodlama.io.Devs.Application.Features.SocialMedia.Github.Models;

// Programming Technology's Using
global using MediatR;
global using System.Reflection;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;




