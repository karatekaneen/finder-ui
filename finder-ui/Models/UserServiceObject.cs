using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class UserServiceObject
    {
        public Group3ServiceReference.Service IncomingService { get; set; }
        public UserProfileServiceReference.User IncomingUser { get; set; }
        public List<ReviewServiceReference.ReviewData> IncomingReview { get; set; }
        public List<ReviewServiceObject> IncomingReviewWithUser { get; set; }
    }
}