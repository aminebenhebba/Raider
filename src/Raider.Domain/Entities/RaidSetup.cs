﻿using System;

namespace Raider.Domain.Entities
{
    public class RaidSetup
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TemplatePath { get; set; }
    }
}