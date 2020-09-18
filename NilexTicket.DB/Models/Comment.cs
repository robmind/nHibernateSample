using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NilexTicket.DB
{

    /// <summary>
    /// There are no comments for Comment in the schema.
    /// </summary>
    public class Comment : IEntity
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
        /// There are no comments for CreateDate in the schema.
        /// </summary>
        public virtual DateTime? CreateDate
        {
            get; 
            set;
        }

    
        /// <summary>
        /// There are no comments for Content_Comment in the schema.
        /// </summary>
        public virtual string Explanation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Ticket in the schema.
        /// </summary>
        public virtual Ticket Ticket
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

        public int Ticket_ID { get; set; }
        public int User_ID { get; set; }
    }

}
