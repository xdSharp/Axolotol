   M S B A M L   `   `   `  ����  DBStore    DBStore.EmployeeWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Сотрудник��5   	   $	��450��6   $	��800��6(    � WindowStartupLocation$ CenterScreen=�64   .��5      � .+�5   
   �� .@�5      �� $��
Книги��6   .��5      �� -   5         ��Name$ BooksListView��5      $��10q�62   ��5	      �� 5
      .R�5      �� 
�������$��1q�68    �� Padding$ 10q�6L   ._�5   "   �� .+�5   &   �� $��16(�6G   $��Segoe UI)�6U   ��60   �� *Title+6U   �� 5   &   $��Segoe UI)�6H   ��60   �� *Author+6H   �� 5   &   $��Segoe UI)�6F   ��60   �� *Year+6F   �� 5   &   -   5        $ ��Редактировать��5   -   ���	#FF4CAF50
�������$��Segoe UI)�6�   
 � Tag 6b   �� *Id+6�   5   #   5      5      5      5      �� 5      $��Заказы��6   .��5      &   System.Windows.Controls.DataGrid  -   5          Name$ OrdersDataGrid��5         AutoGenerateColumns .  $��10q�6O      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6-   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *Id+  5      $ 
Книга��6-   	 6<   �� *
Book.Title+  5      $ Пользователь��6-   	 6C   �� *
User.Login+  5      $ Статус��6-   	 6=   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Действия��61   
   CellTemplate
 5      �� 5    "   .R�5!   &   �� -   5        $��Подтвердить��5!   -   ���	#FF4CAF50
�������$��Segoe UI)�6�    6d   �� *Id+6�   5"   #   5$      5&      5'      5(      5)      5*      