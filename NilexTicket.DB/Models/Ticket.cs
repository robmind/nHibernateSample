using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NilexTicket.DB
{

    /// <summary>
    /// There are no comments for Ticket in the schema.
    /// </summary>
    public class Ticket : IEntity
    {
        /// <summary>
        /// There are no comments for ID in the schema.
        /// </summary>
        public virtual int ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Priority in the schema.
        /// </summary>
        public virtual string Priority
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Title in the schema.
        /// </summary>
        public virtual string Title
        {
            get;
            set;
        }

        public int UserID { get; set; }

        /// <summary>
        /// There are no comments for Content in the schema.
        /// </summary>
        public virtual string Content
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ImageUrl in the schema.
        /// </summary>
        public virtual string ImageUrl
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        public virtual bool? Status
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsItRead in the schema.
        /// </summary>
        public virtual bool? IsItRead
        { 
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreateDate in the schema.
        /// </summary>
        public virtual DateTime? CreateDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Comment in the schema.
        /// </summary>
        public virtual ISet<Comment> Comment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for User in the schema.
        /// </summary>
        public virtual User User
        {
            get;
            set;
        }

        public int User_ID { get; set; }
        public virtual bool IsDeleted
        {
            get;
            set;
        }

        public virtual DateTime? DeleteDate
        {
            get;
            set;
        }
    }

}
