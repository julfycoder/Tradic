   M S B A M L   `   `   `  ����
  Tradic     Tradic.View.Pages.MainPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� ShowsNavigationUI  .   N� 
Background �	#FF931313$
��1000��5   a   $	��700��6n    N� Title$ MainPage��5      .��5
      � .+�5   
   �� $
��Left=�6   $	��212��6-   $��
49,278,0,0q�6:   $	��Top=�6N   $	��258��6f    J� RenderTransformOrigin$ 0.5,0.5&�6r   
����������	#FFECA146$
��Bold"�66  $��18(�6H  ���	#FFE48484��6�   ��  �� Path$ OriginalWords� �� Mode$ TwoWay=� �� SelectedItem 6�   �� $ SelectedOriginalWord�$ TwoWay=���5      �� 5      .R�5      �� ��6    �� $
 Text�5      5      �� 5   
   -   5         ��Name$ ListBox1��5      $
��Left=�6$   $��61��6?   $��
49,138,0,0q�6K   $	��Top=�6_   $	��258��6w   $ 0.5,0.5&�6�   $
��Bold"�6�   $��18(�6�   
����������	#FFECA146���	#FFE48484��6�   �� $ OriginalLanguages�$ OneWay=� 6�   �� $ SelectedOriginalLanguage�$ TwoWay=���5      �� 5      .R�5      �� ��6    �� $
 Name�5      5      �� 5   
   -   5        $ ListBox2��5      $��61��6$   $	��259��60   $��457,138,0,0q�6<   $	��Top=�6Q   $ 0.5,0.5&�6i   $
��Bold"�6�   $��18(�6�   
����������	#FFECA146���	#FFE48484$
��Left=�6q  ��6�   �� $ TranslationLanguages�$ OneWay=� 6�   �� $! SelectedTranslationLanguage�$ TwoWay=���5      �� 5      .R�5      �� ��6    �� $
 Name�5      5      �� 5    
   -   5         ��Name$ RemoveWordButton��5       $��Remove word��6+   $
��Left=�6A   $��
49,490,0,0q�6\   $	��Top=�6p   $	��258��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���	 � Cursor$
	 Hand��6�   $��14(�64  ��6  �� $ RemoveOriginalWordCommand�5"      �� 5#   
   -   5        $ 	AddButton��5#      $��Add word��6$   $
��Left=�67   $��
865,10,0,0q�6R   $	��Top=�6f   $	��125��6~   $��46��6�   
��� ���$
��Bold"�6�   
��� ���$
	 Hand��6�   
��� ���$��18(�6#  ��6�   �� $ GoToAddWordPageCommand�6#  �� 5$   
   -   5        $ RemoveTranslationButton��5$      $��Remove translation��62   $
��Left=�6O   $��456,490,0,0q�6j   $	��258��6   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6*  $	��Top=�68  ��6�   �� $ RemoveTranslationCommand�68  �� 5%   
   $��Translations: ��6   $
��Left=�6)   $��
457,99,0,0q�6D   $	��Top=�6X   $
��Bold"�6q   $��18(�6�   ���	#FFCBEA606�   �� 5&   
   -   5        $ TranslationsBox��5&      $
��Left=�6+   $	��212��6F   $��456,278,0,0q�6S   $	��Top=�6h   $	��259��6�   ���	#FFECA146
�������$��SemiBold"�66  $��18(�6L  ���	#FF7FA233��6�   �� $ TranslationWords�$ TwoWay=� 6�   �� $ SelectedTranslationWord�$ TwoWay=���5'      �� 5(      .R�5)      �� ��6    �� $
 Text�5*      5,      �� 5-   
   -   5        $" RemoveTranslationButton_Copy��5-      $��Add translation��67   $
��Left=�6Q   $��739,362,0,0q�6l   $	��191��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6,  $	��Top=�6:  ��6�   �� $ AddNewTranslationCommand�6:  �� 5.   
   $
��Left=�6   $��84��6-   $��739,278,0,0q�69   
 �� TextWrapping$

 Wrap=�6N   $	��Top=�6�   $	��191��6�   $��18(�6�   ���	#FF242E93$
��Bold"�6  ��6b   �� $ TranslationWord�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.��6   J� InputBindings 5/      �� 50      
 �� Key$ Enter��6    �� Command 6)   �� $ AddNewTranslationCommand�6]   .��51   %   52      �� 53   
   -   5        $ AddButton_Copy��53      $��Testing��6)   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $	��145��6�   $��46��6�   
��� ���$
��Bold"�6�   ���	#FF8ED45D$
	 Hand��6�   ���	#FF8ED45D$��18(�6,  $ 0.5,0.5&�6:  ��6�   �� $ GoToTestingPageCommand�54      �� 55   
   $
��Left=�6   $��73��6-   $��
49,545,0,0q�69   $

 Wrap=�6M   $	��Top=�6�   $	��258��6�   $
��Auto=�6�   ��6a   �� $ OriginalWordDescription�$ TwoWay=�6�   �� 56   
   $
��Left=�6   $��73��6-   $��456,545,0,0q�69   $

 Wrap=�6N   $	��Top=�6�   $	��258��6�   $
��Auto=�6�   ��6b   �� $  TranslationWordDescription�$ TwoWay=�6�   �� 57   
   -	   5        $ RemoveWordButton_Copy��57      $��Save description��60   $
��Left=�6K   $��
49,618,0,0q�6f   $	��Top=�6z   $	��258��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6B  ��6  �� *$"SaveOriginalWordDescriptionCommand+6B  �� 58   
   -
   5        $ RemoveWordButton_Copy1��58      $��Save description��61   $
��Left=�6L   $��456,618,0,0q�6g   $	��Top=�6|   $	��258��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6G  ��6  �� *'%SaveTranslationWordDescriptionCommand+6G  �� 59   
   -   5        $# RemoveTranslationButton_Copy1��59      $��Sort by alphabet��68   $
��Left=�6S   $��307,278,0,0q�6n   $	��120��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6�   $	��Top=�6
  ��6"  �� *$"SortOriginalWordsByAlphabetCommand+�� 5:   
   -   5        $# RemoveTranslationButton_Copy2��5:      $��Sort by knowledge��68   $
��Left=�6T   $��307,311,0,0q�6o   $	��138��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�65  $	��Top=�6C  ��6�   �� *%#SortOriginalWordsByKnowledgeCommand+6C  �� 5;   
   -   5        $# RemoveTranslationButton_Copy3��5;      $��Sort by date added��68   $
��Left=�6U   $��307,344,0,0q�6p   $	��138��6�   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�66  $	��Top=�6D  ��6�   �� *%#SortOriginalWordsByDateAddedCommand+6D  �� 5<   
   -   5        $# RemoveTranslationButton_Copy4��5<      $��Reverse��68   $
��Left=�6J   $��307,393,0,0q�6e   $	��107��6z   $��33��6�   
��� ���
��� ���$��SemiBold"�6�   
��� ���$
	 Hand��6�   $��14(�6#  $	��Top=�61  ��6�   �� *ReverseOriginalWordsCommand+61  �� 5=   
   $
��Left=�6   $��32��6-   $��
49,241,0,0q�69   $

 Wrap=�6M   $	��Top=�6�   $	��258��6�   $��18(�6�   ���	#FF242E93$
��Bold"�6  ��6a   �� $ SearchingSubstring�$ OneWayToSource=�$ PropertyChanged=�6  5>      5?      