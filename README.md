*Passive view* Model-View-Presenter in Windows Forms
====================================================

There are remarkably few straightforward, minimal examples of the *Passive
view* (or *Humble dialog*) variety of the Model-View-Presenter pattern for
Windows Forms.

This project aims to fill the gap.

The common way of using *INotifyPropertyChanged* to connect the model to the
view and have the presenter as a bystander takes us to the *Supervising
Controller* land. Here, by design, everything is managed by the Presenter
instead.

The design is as follows:

![image](https://raw.github.com/mrts/winforms-mvp/master/MVPOverviewClassDiagram.png)
