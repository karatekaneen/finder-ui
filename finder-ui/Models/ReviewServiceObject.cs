using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace finder_ui.Models
{
    public class ReviewServiceObject
    {
        public List<ReviewServiceReference.ReviewData> IncomingReview { get; set; }
        public UserProfileServiceReference.User IncomingReviewUser { get; set; }
    }
}