update ProductTypes
set Name = 'Service (Technician)'
where Name = 'Service'

alter table productTypes
add PurchasingUnit varchar(50)

update ProductTypes
set PurchasingUnit = 'Quantity'
where Name in ('Software', 'Hardware')

update ProductTypes
set PurchasingUnit = 'Hours'
where Name = 'Service (Technician)'

alter table ProductTypes
alter column PurchasingUnit varchar(50) not null
