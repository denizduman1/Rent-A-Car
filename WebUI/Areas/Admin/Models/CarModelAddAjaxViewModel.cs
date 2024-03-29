﻿using Entity.Concrete.DTOs;

namespace WebUI.Areas.Admin.Models
{
    public class CarModelAddAjaxViewModel
    {
        public CarModelAddDto? CarModelAddDto { get; set; }
        public string? CarModelAddPartial { get; set; }
        public CarModelDto? CarModelDto { get; set; } 
    }
}
