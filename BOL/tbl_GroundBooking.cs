//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BOL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_GroundBooking
    {
        public int BookingId { get; set; }
        public Nullable<int> GroundId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> LocationId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual tbl_Ground tbl_Ground { get; set; }
        public virtual tbl_User tbl_User { get; set; }
        public virtual tbl_User tbl_User1 { get; set; }
        public virtual tbl_Category tbl_Category { get; set; }
        public virtual tbl_Location tbl_Location { get; set; }
    }
}
