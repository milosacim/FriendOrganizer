using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Data.Lookups;
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


        public NavigationViewModel(IFriendLookupDataService friendlookupDataService,
            IEventAggregator eventAggregator)
        {
            _friendlookupDataService = friendlookupDataService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
            _eventAggregator.GetEvent<AfteFriendDeletedEvent>().Subscribe(AfterFriendDeleted);

        }



        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookupitem = Friends.SingleOrDefault(l => l.Id == obj.Id);
            if (lookupitem == null)
            {
                Friends.Add(new NavigationItemViewModel(obj.Id, obj.DisplayMember, _eventAggregator));
            } else
            {
                lookupitem.DisplayMember = obj.DisplayMember;

            }
        }
        private void AfterFriendDeleted(int friendId)
        {
            var friend = Friends.SingleOrDefault(f => f.Id == friendId);
            if (friend != null)
            {
                Friends.Remove(friend);
            }
        }

        public async Task LoadAsync()
        {
            var lookup = await _friendlookupDataService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember, _eventAggregator));
            }
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; }

    }
}
