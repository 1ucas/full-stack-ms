using LucasAPI.Domain;
using LucasAPI.Repositories;
using System;

namespace LucasAPI.Services
{
    public class LucasService
    {
        public void Criar(Lucas lucas)
        {
            new LucasWCFRepo().Criar(lucas);
        }
    }
}
