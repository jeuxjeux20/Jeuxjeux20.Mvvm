[![](https://img.shields.io/nuget/v/Jeuxjeux20.Mvvm.svg?style=plastic)](https://www.nuget.org/packages/Jeuxjeux20.Mvvm/)
# Jeuxjeux20.Mvvm
A simple but yet __incredible__ MVVM micro-framework.

This project contains helper classes for building a trully MVVM project.

## Details

| Class                                               | Purpose                                                                                            |
|-----------------------------------------------------|----------------------------------------------------------------------------------------------------|
| `DelegateCommand`                                   | Easily create an annonymous `ICommand` using delegates                                                          |
| `PropertyChangedObject`                             | A multi-threaded object that implements `INotifyPropertyChanged`                                  |
| `IViewModel<TModel>`                                | An interface for each viewmodel that references the model                                          |
| `ViewModelBase<TModel>`                             | A class that implements `PropertyChangedObject`,  and can be used for simpler and shorter viewmodels |
| `ObservableModelCollection<TModel>`                      | An observable collection of models                                                                 |
| `ObservableViewModelCollection<TViewModel, TModel>` | An observable collection of viewmodels and their models                                            |

A deeper documentation of each class is on its way.

