﻿using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IFriendLookupDataService _friendlookupDataService;
        private IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedFriend;


        public NavigationViewModel(IFriendLookupDataService friendlookupDataService,
            IEventAggregator eventAggregator)
        {
            _friendlookupDataService = friendlookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);

        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookupitem = Friends.Single(l => l.Id == obj.Id);
            lookupitem.DisplayMember = obj.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendlookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; }

        public NavigationItemViewModel SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                        .Publish(_selectedFriend.Id);
                }
            }
        }

    }
}
