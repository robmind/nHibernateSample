using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NilexTicket.DB
{

    /// <summary>
    /// There are no comments for User in the schema.
    /// </summary>
    public class User : IEntity
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
        /// There are no comments for Username in the schema.
        /// </summary>
        public virtual string Username
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FullName in the schema.
        /// </summary>
        public virtual string FullName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Password in the schema.
        /// </summary>
        public virtual string Password
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Mail in the schema.
        /// </summary>
        public virtual string Mail
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Role in the schema.
        /// </summary>
        public virtual string Role
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
        /// There are no comments for Ticket in the schema.
        /// </summary>
        public virtual ISet<Ticket> Ticket
        {
            get;
            set;
        }
    }

}
