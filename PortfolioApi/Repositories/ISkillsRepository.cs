﻿using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface ISkillsRepository
{
    public Task<List<SkillDTO>> Get();

    public Task<SkillDTO> Get(int id);

    public Task<SkillDTO> Add(SkillCreateDTO skillCreateDTO);

    public Task<SkillDTO> Put(SkillDTO skillDTO);

    public Task Delete(int id);
}
