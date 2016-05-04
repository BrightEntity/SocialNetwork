using System;

namespace SocialNetwork.Models
{
    public delegate void CreationEventHandler(object sender, CreationEventArgs e);
    public delegate void ModificationEventHandler(object sender, ModificationEventArgs e);

    public class ModificationEventArgs : EventArgs
    {
    }

    public class CreationEventArgs : EventArgs
    {
    }

    public interface IDatable
    {
        DateTime CreatedAt { get; set; }
        DateTime ModifiedAt { get; set; }

        event CreationEventHandler Created;
        event ModificationEventHandler Modified;
        
    }
    
}