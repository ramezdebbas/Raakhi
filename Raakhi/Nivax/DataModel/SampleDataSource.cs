﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace InvitationTemplate.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : InvitationTemplate.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._subtitle = subtitle;
            this._description = description;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get { return this._subtitle; }
            set { this.SetProperty(ref this._subtitle, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private SampleDataGroup _group;
        public SampleDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup : SampleDataCommon
    {
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
        }

        private ObservableCollection<SampleDataItem> _items = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> Items
        {
            get { return this._items; }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// </summary>
    public sealed class SampleDataSource
    {
        private ObservableCollection<SampleDataGroup> _itemGroups = new ObservableCollection<SampleDataGroup>();
        public ObservableCollection<SampleDataGroup> ItemGroups
        {
            get { return this._itemGroups; }
        }

        public SampleDataSource()
        {
            String ITEM_CONTENT = String.Format("Item Content: {0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}\n\n{0}",
                        "Curabitur class aliquam vestibulum nam curae maecenas sed integer cras phasellus suspendisse quisque donec dis praesent accumsan bibendum pellentesque condimentum adipiscing etiam consequat vivamus dictumst aliquam duis convallis scelerisque est parturient ullamcorper aliquet fusce suspendisse nunc hac eleifend amet blandit facilisi condimentum commodo scelerisque faucibus aenean ullamcorper ante mauris dignissim consectetuer nullam lorem vestibulum habitant conubia elementum pellentesque morbi facilisis arcu sollicitudin diam cubilia aptent vestibulum auctor eget dapibus pellentesque inceptos leo egestas interdum nulla consectetuer suspendisse adipiscing pellentesque proin lobortis sollicitudin augue elit mus congue fermentum parturient fringilla euismod feugiat");

            var group1 = new SampleDataGroup("Group-1",
                    "Best Raakhi Cards",
                    "Group Subtitle: 1",
                    "Assets/BrownTile.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group1.Items.Add(new SampleDataItem("Group-1-Item-1",
                    "Card 01",
                    "",
                     "Assets/Images/11.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group1));
            group1.Items.Add(new SampleDataItem("Group-1-Item-2",
                    "Card 02",
                    "",
                     "Assets/Images/12.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group1));
            group1.Items.Add(new SampleDataItem("Group-1-Item-3",
                    "Card 03",
                    "",
                     "Assets/Images/13.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group1));
            group1.Items.Add(new SampleDataItem("Group-1-Item-4",
                    "Card 04",
                    "",
                     "Assets/Images/14.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group1));
            this.ItemGroups.Add(group1);

            
			var group2 = new SampleDataGroup("Group-2",
                    "Superb Raakhi Cards",
                    "Group Subtitle: 1",
                    "Assets/BrownTile.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group2.Items.Add(new SampleDataItem("Group-2-Item-1",
                    "Card 01",
                    "",
                     "Assets/Images/21.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group2));
            group2.Items.Add(new SampleDataItem("Group-2-Item-2",
                    "Card 02",
                    "",
                     "Assets/Images/22.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group2));
            group2.Items.Add(new SampleDataItem("Group-2-Item-3",
                    "Card 03",
                    "",
                     "Assets/Images/23.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group2));
            group2.Items.Add(new SampleDataItem("Group-2-Item-4",
                    "Card 04",
                    "",
                     "Assets/Images/24.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group2));
            this.ItemGroups.Add(group2);
			
			 
			var group3 = new SampleDataGroup("Group-3",
                    "Classic Raakhi Cards",
                    "Group Subtitle: 1",
                    "Assets/BrownTile.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group3.Items.Add(new SampleDataItem("Group-3-Item-1",
                    "Card 01",
                    "",
                     "Assets/Images/31.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group3));
            group3.Items.Add(new SampleDataItem("Group-3-Item-2",
                    "Card 02",
                    "",
                     "Assets/Images/32.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group3));
            group3.Items.Add(new SampleDataItem("Group-3-Item-3",
                    "Card 03",
                    "",
                     "Assets/Images/33.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group3));
            group3.Items.Add(new SampleDataItem("Group-3-Item-4",
                    "Card 04",
                    "",
                     "Assets/Images/34.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group3));
            this.ItemGroups.Add(group3);
			
			 
			var group4 = new SampleDataGroup("Group-4",
                    "Awesome Raakhi Cards",
                    "Group Subtitle: 1",
                    "Assets/BrownTile.png",
                    "Group Description: Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus tempor scelerisque lorem in vehicula. Aliquam tincidunt, lacus ut sagittis tristique, turpis massa volutpat augue, eu rutrum ligula ante a ante");
            group4.Items.Add(new SampleDataItem("Group-4-Item-1",
                    "Card 01",
                    "",
                     "Assets/Images/41.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group4));
            group4.Items.Add(new SampleDataItem("Group-4-Item-2",
                    "Card 02",
                    "",
                     "Assets/Images/42.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group4));
            group4.Items.Add(new SampleDataItem("Group-4-Item-3",
                    "Card 03",
                    "",
                     "Assets/Images/43.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group4));
            group4.Items.Add(new SampleDataItem("Group-4-Item-4",
                    "Card 04",
                    "",
                     "Assets/Images/44.png",
                    "Hi! I’d like to celebrate my birthday with you this Sat,June 18th, at Mc Donald’s RCity Mall. The party shall begin from 7 pm. See ya!",
                    ITEM_CONTENT,
                    group4));
            this.ItemGroups.Add(group4);

        }
    }
}
