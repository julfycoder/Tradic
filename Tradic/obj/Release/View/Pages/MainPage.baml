   M S B A M L   `   `   `  ���� 
  Tradic     Tradic.View.Pages.MainPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� ShowsNavigationUI  .   N� 
Background �	#FF931313 N� Title$ MainPage��.��� .+��� $
��Left=�$	��212��$��287,105,0,0q�$	��Top=�$	��242�� J� RenderTransformOrigin$ 0.5,0.5&�
����������	#FFECA146$
��Bold"�$��18(����	#FFE48484����  �� Path$ OriginalWords� �� Mode$ TwoWay=� �� SelectedItem �� $ SelectedOriginalWord�$ TwoWay=����� .R��� ���� $
 Text��� -    ��Name$ ListBox1��$
��Left=�$	��229��$��	74,88,0,0q�$	��Top=�$	��160��$ 0.5,0.5&�$
��Bold"�$��18(�
����������	#FFECA146���	#FFE48484���� $ OriginalLanguages�$ OneWay=� �� $ SelectedOriginalLanguage�$ TwoWay=����� .R��� ���� $
 Name��� -   $ ListBox2��$	��229��$	��160��$��579,88,75,0q�$	��Top=�$ 0.5,0.5&�$
��Bold"�$��18(�
����������	#FFECA146���	#FFE48484���� $ TranslationLanguages�$ OneWay=� �� $! SelectedTranslationLanguage�$ TwoWay=����� .R��� ���� $
 Name��� -    ��Name$ RemoveWordButton��$��Remove word��$
��Left=�$��
287,67,0,0q�$	��Top=�$	��242��$��33��
��� ���
��� ���$��SemiBold"�
��� ���	 � Cursor$
	 Hand��$��14(����� $ RemoveOriginalWordCommand��� -   $ 	AddButton��$��Add word��$
��Left=�$��
679,10,0,0q�$	��Top=�$	��125��$��46��
��� ���$
��Bold"�
��� ���$
	 Hand��
��� ���$��18(����� $ GoToAddWordPageCommand��� -   $ RemoveTranslationButton��$��Remove translation��$
��Left=�$��287,477,0,10q�$	��242��$��28��
��� ���
��� ���$��SemiBold"�
��� ���$
	 Hand��$��14(����� $ RemoveTranslationCommand��� $��Translations: ��$
��Left=�$��287,322,0,0q�$	��Top=�$
��Bold"�$��18(����	#FFCBEA60�� -   $ TranslationsBox��$
��Left=�$	��119��$��287,353,0,0q�$	��Top=�$	��242�����	#FFECA146
�������$��SemiBold"�$��18(����	#FF7FA233���� $ TranslationWords�$ TwoWay=� �� $ SelectedTranslationWord�$ TwoWay=����� .R��� ���� $
 Text��� -   $" RemoveTranslationButton_Copy��$��Add translation��$
��Left=�$��579,353,0,134q�$	��160��$��28��
��� ���
��� ���$��SemiBold"�
��� ���$
	 Hand��$��14(����� $ AddNewTranslationCommand��� $
��Left=�$��49��$��579,386,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��160��$��18(����	#FF242E93$
��Bold"����� $ TranslationWord�$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.�� J� InputBindings �� 
 �� Key$ Enter�� �� Command �� $ AddNewTranslationCommand�.���� -   $ AddButton_Copy��$��Testing��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��145��$��46��
��� ���$
��Bold"����	#FF8ED45D$
	 Hand�����	#FF8ED45D$��18(�$ 0.5,0.5&����� $ GoToTestingPageCommand�