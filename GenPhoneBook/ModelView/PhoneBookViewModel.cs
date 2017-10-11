using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenPhoneBook.Model;

namespace GenPhoneBook.ModelView
{
    class PhoneBookViewModel : ViewModelBase
    {
        private PhoneBookModel _selectPhone;
        private ViewModelBase _addPhone;

        public ObservableCollection<PhoneBookModel> PhoneBook { get; set; }

        public PhoneBookModel SelectPhone
        {
            get
            {
                return _selectPhone;
            }
            set
            {
                _selectPhone = value;
                OnPropertyChanged("SelectPhone");
            }
        }

        public PhoneBookViewModel()
        {
            PhoneBook = new ObservableCollection<PhoneBookModel>
            {
                new PhoneBookModel { Name = "1", Phone = "1234567", MobilePhone = "789456123"},
                new PhoneBookModel { Name = "2", Phone = "7654321", MobilePhone = "321654987"}
            };
        }

        public ViewModelBase AddPhone
        {
            get
            {
                return _addPhone ??
                    (_addPhone = new ViewModelBase(obj =>
                    {
                        PhoneBookModel model = new PhoneBookModel();
                        PhoneBook.Add(model);
                        SelectPhone = model;
                    }));
            }
        }

    }
}
