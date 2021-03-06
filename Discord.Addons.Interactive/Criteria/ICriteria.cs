﻿using System.Threading.Tasks;
using Discord.Commands;

namespace Discord.Addons.Interactive
{
    public interface ICriterion<T>
    {
        Task<bool> JudgeAsync(SocketCommandContext sourceContext, T parameter);
    }
}