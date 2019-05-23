using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using finder_ui.Group3ServiceReference;

namespace finder_ui.Models
{
    public class EditServiceObject
    {
        

        public EditServiceObject(int id, int type, int serviceStatusId, string picture, string title, string description, double price, DateTime? startDate, DateTime? endDate, bool timeNeeded, int subCategoryId)
        {
            Id = id;
            Type = Type;
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

       /* public EditServiceObject(int id, int type, int serviceStatusId, string picture, string title, string description, double price, DateTime? startDate, DateTime? endDate, bool timeNeeded, int subCategoryId, List<ServiceStatusType> statuses, List<SubCategory> subCategories, List<ServiceType> serviceTypes) : this(id, type, serviceStatusId, picture, title, description, price, startDate, endDate, timeNeeded, subCategoryId)
        {
            this.statuses = statuses;
            this.subCategories = subCategories;
            this.serviceTypes = serviceTypes;
        }*/

        public EditServiceObject(int id, int type, int serviceStatusId, string picture, string title, string description, double price, DateTime? startDate, DateTime? endDate, bool timeNeeded, int subCategoryId, List<ServiceStatusType> statuses, List<SubCategory> subCategories, List<Category> categories, List<ServiceType> serviceTypes) : this(id, type, serviceStatusId, picture, title, description, price, startDate, endDate, timeNeeded, subCategoryId)
        {
            StatusList = statuses;
            SubCategoryList = subCategories;
            CategoryList = categories;
            ServiceTypeList = serviceTypes;
        }

        public int Id { get; set; }
        public int Type { get; set; }
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
        public List<Category> CategoryList { get; set; }
        public List<ServiceType> ServiceTypeList { get; set; }

    }
}
