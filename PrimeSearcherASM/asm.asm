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

return1 proc 
	mov eax, 1
	ret
return1 endp
end
