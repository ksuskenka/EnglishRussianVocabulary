   M S B A M L   `   `   `  ����#  EnglishRussianTranslator.Client)    #EnglishRussianTranslator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$   ��5   	   $��521.642��6   $��626.093��6#    � Icon$ google translate.ico��63    � 
ResizeMode$ NoResize=�6O   .��5      �  � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��1* �6    � ColumnDefinitions 5
   
   .+�5   
   ]� $��Stretch=�6   $��0��5      $��Stretch=�6!   $��0,0,0,10q�6=   .+�5      �� -   5         ��Name$ uiAddBtn��5      $��Stretch=�6(   $��89��6D   $
��Left=�6O   $��0,0,7,0q�6j   .��5      ]� .+�5      �� $��Images/add.png��6   $��20��64   6B   �� 5      $��Добавить��6    $��5,0,0,0q�60   6C   5      5      �� 5      -   5        $ 	uiEditBtn��5      $��Stretch=�6(   $	��125��6D   $��0,0,7,0q�6P   $
��Left=�6a   .��5      ]� .+�5      �� $��Images/edit.png��6   $��20��65   6C   �� 5      $ ��Редактировать��6    $��5,0,0,0q�65   6H   5      5      �� 5      -   5        $ uiDeleteBtn��5      $��50��6*   $	��Top=�66   $��87��6N   .��5      ]� $��Stretch=�6   $��Stretch=�68   $��77��6V   $��26��6a   .+�5      �� $��Images/delete.png��6   $��25��67   $
��Left=�6C   6`   �� 5      $��Удалить��6    $��5,0,0,0q�6/   6B   5      5       �� 5!      $��60��6   $	��Top=�6%   $	��119��6=   $
��Left=�6I   .+�5"      �� -   5         ��Name$ uiLanguageCbx��5"      $��30��62   $��0,15,0,0q�6>   $��Center=�6Q    �� DisplayMemberPath$ LanguageName��5$       �� SelectedValuePath$ ID��5%      ��5#      �� 	 �� Path$	 LanguageType�
 �� SelectedValue
 5&      �� $	 CurrentLanguage.ID� �� SelectedItem 5'      �� $	 CurrentLanguage�5(      �� 5)      -   5         ��Name$ uiSearchTextbox��5)      $��24��6/   $	��109��6;    �� TextWrapping$
 Wrap=�6G   $��Right=�6|   $��Center=�6�   $��
10,23,0,13q�6�   ��6[   �� $	 
Searchword�6�   �� 5*      -   5        $ uiSearchBtn��5*      $��
Найти��6*   $��Stretch=�6;   $��59��6W   $��Right=�6b   6~   5,      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ uiWordsDataGrid��5-      $��Stretch=�6,      
IsReadOnly .    SelectionMode$ Single=�6\      AutoGenerateColumns .  $��1��6�   $��Stretch=�6�   ��6�   �� $	 TranslateVariations�   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6A      Width5  /System.Windows.Controls.DataGridLengthConverter$ 0 6U   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� $	 ID�6U     50         Header$ 
Слово��6%   $ Visible=�6^   $ * 6s    65   �� $	 TranslationWord�6s   53      56      57      