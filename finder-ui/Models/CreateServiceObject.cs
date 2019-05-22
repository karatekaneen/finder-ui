using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using finder_ui.Group3ServiceReference;

namespace finder_ui.Models
{
    public class CreateServiceObject
    { 

        public CreateServiceObject(List<ServiceStatusType> statuses, List<SubCategory> subCategories, List<ServiceType> serviceTypes, List<Category> categories)
        {
            StatusList = statuses;
            SubCategoryList = subCategories;
            ServiceTypeList = serviceTypes;
            CategoryList = categories;
        }

        public CreateServiceObject(int type, int creatorId, int serviceStatusId, string picture, string title, string description, double price, DateTime? startDate, DateTime? endDate, bool timeNeeded, int subCategoryId)
        {
            Type = type;
            CreatorId = creatorId;
            ServiceStatusId = serviceStatusId;
            Picture = picture;
            Title = title;
            Description = description;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            TimeNeeded = timeNeeded;
            SubCategoryId = subCategoryId;
        }

        public int Type { get; set; }
        public int CreatorId { get; set; }
        public int ServiceStatusId { get; set; }
        public string Picture { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool TimeNeeded { get; set; }
        public int SubCategoryId { get; set; }
        public List<ServiceStatusType> StatusList { get; set; }
        public List<SubCategory> SubCategoryList { get; set; }
        public List<ServiceType> ServiceTypeList { get; set; }
        public List<Category> CategoryList { get; set; }
    }
}