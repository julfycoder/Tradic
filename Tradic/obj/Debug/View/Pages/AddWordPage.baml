   M S B A M L   `   `   `  ����
  Tradic#    Tradic.View.Pages.AddWordPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� ShowsNavigationUI  .   N� 
Background �	#FF931313 N� Title$ AddWordPage��5      .��5
      � $
��Left=�6   $	��814��6&   $	��515��62   $	��Top=�6?   .+�5   
   �� $��Original language��6   $
��Left=�6,   $��
116,93,0,0q�6G   $	��Top=�6[   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5   
   $��Translation language��6   $
��Left=�6/   $��
549,93,0,0q�6J   $	��Top=�6^   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5   
   $��Translation word��6   $
��Left=�6+   $��549,229,0,0q�6F   $	��Top=�6[   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5   
   $��Original word��6   $
��Left=�6(   $��116,229,0,0q�6C   $	��Top=�6X   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ OrigianlWordBox��5      $
��Left=�6+   $��116,260,0,229q�6F    �� TextWrapping$
 Wrap=�6]   $	��187��6q   ���	#FFE48484$��18(�6�   $
��Bold"�6�   ��6}   ��  �� Path$ OriginalWordText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6   J� InputBindings 5      �� 5      
	 �� Key$	 Enter��6   
 �� Command
 6)   �� $ AddNewWordCommand�6V   .��5   %   5      �� 5   
   -   5        $ TranslationWordsBox��5      $
��Left=�6/   $��549,260,0,0q�6J   $
 Wrap=�6_   $	��187��6s   ���	#FFE48484$��18(�6�   $
��Bold"�6�   $��26��6  $	��Top=�6  ��6   �� $ TranslationWordText�$ TwoWay=�$ PropertyChanged=�.��65   5      �� 5      $	 Enter��6   
 6)   �� $ AddNewWordCommand�6V   .��5   %   5      �� 5   
   -   5         ��Name$ OriginalLanguagesBox��5      $
��Left=�60   $��87��6K   $��116,124,0,0q�6W   $	��Top=�6l   $	��187��6�   $��18(�6  ���	#FFE48484$
��Bold"�65  ��6�   �� $ OriginalLanguages�$ TwoWay=� �� SelectedItem 6�   �� $ SelectedOriginalLanguage�$ TwoWay=���5      �� 5      .R�5      �� ��6    �� $
 Name�5      5      �� 5    
   -   5        $ TranslationLanguagesBox��5       $��87��63   $��549,124,78,0q�6?   $	��Top=�6U   ���	#FFE48484$��18(�6
  $
��Bold"�6  ��6m   �� $ TranslationLanguages�$ TwoWay=� 6�   �� $! SelectedTranslationLanguage�$ TwoWay=���5!      �� 5"      .R�5#      �� ��6    �� $
 Name�5$      5&      �� 5'   
   -   5         ��Name$ WatchButton��5'      $��
Dictionary��6&   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $	��157��6�   $��46��6�   
��� ���
��� ���$
��Bold"�6�   
��� ��� � Cursor$
 Hand��6�   $��18(�6#  ��6�   �� $ GoToMainPageCommand�6#  �� 5(   
   $��Add Word��6   $
��Left=�6$   $��305,417,0,0q�6?   $	��Top=�6T   $	��200��6l   $��47��6y   ���	#FF0FC96C
��� ���$
��Bold"�6�   ���	#FF0FC96C$
 Hand��6�   $��16(�6  ��6�   �� $ AddNewWordCommand�6  �� 5)   
   $
��Left=�6   $��23��6-   $��116,338,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��187��6�   ��6b   �� $ OriginalWordDescription�$ TwoWay=�6�   �� 5*   
   $��Description��6   $
��Left=�6&   $��116,304,0,0q�6A   $	��Top=�6V   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5+   
   $��Description��6   $
��Left=�6&   $��549,304,0,0q�6A   $	��Top=�6V   ���	#FFCBEA60$��18(�6�   $
��Bold"�6�   �� 5,   
   $
��Left=�6   $��23��6-   $��549,338,0,0q�69   $
 Wrap=�6N   $	��Top=�6�   $	��187��6�   ��6b   �� $  TranslationWordDescription�$ TwoWay=�6�   5.      5/      