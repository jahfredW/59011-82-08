select * from supplier s inner join sale_offer so 
on s.id = so.supplier_id 
where so.delivery_time <= 15

select count(so.item_id), so.supplier_id  from supplier s  join sale_offer so 
on s.id = so.supplier_id 
group by so.supplier_id 

select * from supplier s
where ( select count(so.item_id) from sale_offer so where s.id = so.supplier_id) > 2


select so.supplier_id  count(*) as total from supplier s join sale_offer so on s.id = so.supplier_id 
group by so.supplier_id having count(*) > 2



select * from "order" o inner join order_line ol on o.id = ol.order_id 
where ol.delivered_quantity != ol.ordered_quantity 

select * from item i inner join sale_offer so on i.id = so.item_id 
inner join supplier s on s.id  = so.supplier_id 
where s."name" = 'DICOBOL'

select * from "order" o where   o."date" < date  '2021-01-20'
and o."date" > date '2021-01-10'

select o.id, count(*) from "order" o inner join order_line ol 
on o.id = ol.order_id 
inner join item i on i.id  = ol.item_id 
group by o.id 

select * from "order" o 
where o.id in (
select ol.order_id  from  order_line ol
group by ol.order_id 
having  count( ol.item_id) > 4)


select distinct *  from "order" o where o.supplier_id in(
select s.id from "supplier" s where s.id in 
( select so.supplier_id  from sale_offer so where so.delivery_time < 15 ))


select * from "order" o join order_line ol 
on o.id = ol.order_id join item i 
on i.id = ol.item_id
where i.stock < i.stock_alert 


select * from "order" o where o.id in ( 
select ol.order_id  from order_line ol where ol.item_id in 
(select i.id from item i where i.stock_alert > i.stock))


select * from "supplier" s where s.id in 
( select so.supplier_id  from sale_offer so where so.delivery_time <= 15 )


select * from supplier s where s.id in  (
select o.supplier_id  from "order" o where o.id in (
select ol.order_id  from order_line ol group by order_id 
having sum(ol.delivered_quantity * ol.unit_price) >= 10000000  ))


select s.* from supplier s inner join 
"order" o 
on s.id = o.supplier_id inner join 
order_line ol 
on ol.order_id = o.id group by s.id having sum(ol.delivered_quantity * ol.unit_price) > 10000000






