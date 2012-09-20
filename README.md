*Passive view* Model-View-Presenter in Windows Forms
====================================================

There are remarkably few straightforward, minimal examples of the *Passive
view* (or *Humble dialog*) variety of the Model-View-Presenter pattern for
Windows Forms.

This project aims to fill the gap.

Note that there are no attempts to use *INotifyPropertyChanged*, everything is
managed by the Presenter. This is by design - *INotifyPropertyChanged* takes us
to the *Supervising Controller* land.
