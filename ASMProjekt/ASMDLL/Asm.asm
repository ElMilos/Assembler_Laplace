
.code

; normalizacja
LimitToRange Proc

test edi, edi
Js LimitToRangeZERO ; JL - jezeli mniejsza od zera
CMP rdi, 255
JG LimitToRange255 ; JG - jezeli wieksza od zera

ret ;je�eli warto�� jest w przedziale

LimitToRangeZERO:
xor rdi, rdi ; ustawiamy na 0
ret

LimitToRange255:
xor rdi, rdi
MOV rdi, 255 ; ustawiamy na 255
ret

LimitToRange ENDP


MyProc1 proc

    ; RCX - wska�nik na tablic� bajt�w (BGR)
    ; RDX - wielko�� tablicy -startowa 27
    ; R8  - wska�nik na tablic� bajt�w (BGR)

    ; R15 - R
    ; R14 - G
    ; R13 - B

; DODA� NA POCZATEK SKOK DO PETLI G�OWNEJ

jmp _start



_start:
    ; Inicjalizacja sumy
    xor r13, r13 ; Zerowanie rejestru r13
    xor r14, r14 ; Zerowanie rejestru r14
    xor r15, r15 ; Zerowanie rejestru r15

    Mainloop:


    test rdx, rdx ; sprawdzenie czy przesz�o si� po wszystkich elementach tablicy
    jz endCalc

    jmp blue    ; skok do obliczania warotsci blue
    BBack:

    add rcx ,4   ;przesuni�cie wska�nika stosu
    dec rdx      ;dekrem

    jmp green
    GBack:

    add rcx ,4   ;przesuni�cie wska�nika stosu
    dec rdx      ;dekrem

    jmp red
    RBack:

    add rcx ,4  ;przesuni�cie wska�nika stosu
    dec rdx      ;dekrem

    add r8 ,4   ;nastepny element macierzy 

    jmp Mainloop

    
blue:



movdqu xmm0, [rcx] ; Za�adowanie danych z tablicy do xmm0
movdqu xmm1, [r8] ; Za�adowanie warto�ci macierzy do xmm1
pmulld  xmm0, xmm1 ; pomno�enie przez siebie za�adowanych warto�ci
movd eax, xmm0 ; Skopiowanie wyniku do rejestru eax
add r13d, eax   ; Dodanie warto�ci do r13d
xor rax, rax ; Zerowanie rejestru rax

jmp BBack ; powr�t do g��wnej p�tli

green:

movdqu xmm0, [rcx] ; Za�adowanie danych z tablicy do xmm0
movdqu xmm1, [r8] ; Za�adowanie pierwszej warto�ci macierzy do xmm1
pmuludq xmm0, xmm1
movd eax, xmm0 ; Skopiowanie wyniku do rejestru rax
add r14d, eax   ; Dodanie warto�ci do r13
xor rax, rax ; Zerowanie rejestru rax

jmp GBack

red:

movdqu xmm0, [rcx] ; Za�adowanie danych z tablicy do xmm0
movdqu xmm1, [r8] ; Za�adowanie pierwszej warto�ci macierzy do xmm1
pmuludq xmm0, xmm1
movd eax, xmm0 ; Skopiowanie wyniku do rejestru rax
add r15d, eax   ; Dodanie warto�ci do r13
xor rax, rax ; Zerowanie rejestru rax

jmp RBack


endCalc:


xor rdi,rdi
mov rdi,r13
CALL LimitToRange
xor r13,r13
mov r13,rdi

xor rdi,rdi
mov rdi,r14
CALL LimitToRange
xor r14,r14
mov r14,rdi

xor rdi,rdi
mov rdi,r15
CALL LimitToRange
xor r15,r15
mov r15,rdi

xor rax,rax


mov [r9], r13d     
mov [r9 + 4], r14d 
mov [r9 + 8], r15d 


ret
 MyProc1 ENDP


END