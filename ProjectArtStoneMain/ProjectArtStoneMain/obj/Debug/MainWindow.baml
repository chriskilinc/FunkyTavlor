   M S B A M L   `   `   `  ����N  JProjectArtStoneMain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ProjectArtStoneMainProjectArtStoneMain  5      e aMicrosoft.WindowsAzure.Storage, Version=6.2.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�Zclr-namespace:Microsoft.WindowsAzure.Storage.Table;assembly=Microsoft.WindowsAzure.Storage$Microsoft.WindowsAzure.Storage.Table 5      $    ProjectArtStoneMain.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      3local!clr-namespace:ProjectArtStoneMain     5      lTableZclr-namespace:Microsoft.WindowsAzure.Storage.Table;assembly=Microsoft.WindowsAzure.Storage     5        � Title$  
MainWindow��5	      $��368.374��6   $��689.637��6'   ���	#FF2B2B2B   MaterialDesignBody#���   5
      $X��Rpack://application:,,,/MaterialDesignThemes.Wpf;component/Resources/Roboto/#Roboto)�5      ���	#DDFFFFFF.��5      � .+�5   
   �� -   5         ��Name$ 	btnUpload��5      $��	Ladda Upp��6$   $
��Left=�68   $��436,292,0,0q�6S   $	��Top=�6h   $��72��6�   ���	#FFDDDDDD���	#FFFF98006�   �� 5   
   -   5         ��Name$ image��5      $
��Left=�6   $	��121��6:   $��
436,10,0,0q�6G   $	��Top=�6[   $	��216��6s   $��Images/216x121.png��6   �� 5   
   -   5         ��Name$ listBox��5      $
��Left=�6#   $	��285��6>   $	��Top=�6K   $	��165��6c   $ �� IsSynchronizedWithCurrentItem$ FalseY�6o   ���	#DDFFFFFF���	#FFFF9800��5      �� 5      .R�5      �� ��6    �� *PartitionKey+5      5      �� 5   
   -   5        $ 	btnRemove��5      $��Ta bort��6$   $
��Left=�66   $��553,292,0,0q�6Q   $	��Top=�6f   $��80��6~   ���	#FFDDDDDD���	#FFFF98006�   �� 5   
   -   5        $ button��5      $��Refresh��6!   $
��Left=�63   $��
10,297,0,0q�6N   $	��Top=�6b   $��85��6z   6�   �� 5   
   -   5         ��Name$ txbDescription��5      $
��Left=�6,   $��436,164,0,0q�6G   $
��Wrap=�6\   $	��Top=�6p   $	��123��6�   $	��158��6�   �� 5   
   -   5         ��Name$ label��5      $��Description:��6   $
��Left=�66   $��428,131,0,0q�6Q   $	��Top=�6f   
�������6~   5      5      