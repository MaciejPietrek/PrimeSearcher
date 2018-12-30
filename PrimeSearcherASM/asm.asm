.486
.model flat, stdcall

; *************************************************************************
; Data segment starts here
; *************************************************************************
.data

; *************************************************************************
; Our executable assembly code starts here in the .code section
; *************************************************************************
.code

; *************************************************************************
; Dummy function
; *************************************************************************
return1 proc 
	mov eax, 1
	ret
return1 endp

; *************************************************************************
; This procedure returns 1 if the number is prime or 0 if it's not
; *************************************************************************
isPrime proc number : DWORD

	push ebx			; Secures the ebx register value
	mov ecx, 1			; In ecx will be the divisors kept
	mov ebx, number		; Stores the tested intiger in this register
;	mov ebx, [ebx]

checkIfEqualToTwo:		;
	cmp ebx, 2			;
	je isDivisible		;

incrementDivisor:		; Increments the divisor
	inc ecx				; Increments the ecx register which contains the divisor
	cmp ecx, ebx		; Compares if the divisor is eaqual to the number (stop execution if true, number is prime)
	je isPrimeEt		; Jumps to isPrimeEt which ends the procedure
	
divide:					; Divides the divider by the divisor
	xor edx, edx		; Makes zero in edx
	mov	eax, ebx		; Moves the divider to eax
	div ecx				; Divides divider (eax/number) by divior (ecx), it returns result into eax and remainder into edx

checkDivisible:			; Checks if the remainder is 0 (the divider is divisible by the divisor)
	cmp edx, 0			; Compares the reminder to 0
	je isDivisible		; If zero -> is divisible -> move to isDivisible

isNotDivisible:			; Is not divisible
	jmp incrementDivisor; Moves to increament the divisor and continue the next loop

isDivisible:			; Is divisible
	mov eax, 0			; Moves 0 to eax (acumulator) which means the number is not prime
	pop ebx				; Restores the ebx value
	ret

isPrimeEt:				; Is prime 
	mov eax, 1			; Moves 1 to eax (acumulator) which means the number is prime
	pop ebx				; Restores the ebx value
	ret

isPrime endp
end
